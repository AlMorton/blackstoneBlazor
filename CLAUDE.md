# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project

Blazor WebAssembly app that automates the AI/behaviour rules of the board game *Warhammer Quest: Blackstone Fortress*
(https://boardgamegeek.com/boardgame/264198/warhammer-quest-blackstone-fortress). Client-side only — there is no server
project or API; all game data is static JSON served from `wwwroot` and fetched over `HttpClient`.

## Commands

```bash
npm install                    # required before the first build: Sass imports bootstrap from ./node_modules
npm run sass                   # compile Sass/style.scss -> wwwroot/css/site.css (also run automatically pre-build)
npm run sasswatch              # watch mode while iterating on styles

dotnet run                     # serve the app (https://localhost:7286 / http://localhost:5286)
dotnet watch                   # run with hot reload
dotnet build                   # BlazorApp.csproj; a BeforeTargets="Build" target shells out to `npm run sass`

dotnet test Tests/Tests.csproj
dotnet test Tests/Tests.csproj --filter FullyQualifiedName~JsonTest   # single test
```

`npm test` is not wired up — it just exits 1.

## Architecture

### Component pattern (follow this for new components)

Every component is split in two files: a plain `ComponentBase` subclass in C# holding all state, injection and logic,
and a `.razor` view that binds to it with `@inherits`. Examples: `Components/EnemyComponent.cs` +
`Components/EnemyView.razor`, `Pages/ArenaCompenent.cs` + `Pages/Arena.razor`. Only `Shared/MainLayout.razor` and
`Shared/NavMenu.razor` use inline `@code` blocks. `[Inject]` properties go on the C# class, not the view.

Routing lives on the views via `@page`. Note that `Components/EnemyGroupView.razor` is a routable page
(`/enemygroup/{groupNumber:int}`) despite sitting in `Components/` — routes are not confined to `Pages/`.

### State

`EnemyService` (scoped in `Program.cs`, i.e. one instance for the whole WASM session) is the app-wide mutable store,
not just a data loader. It owns:

- `EnemyGroups` — a fixed `Dictionary<int, EnemyGroup>` of groups 1–8, created in `SetupGroups()`.
- `InitiativeTrack` — the ordered `List<IInitiativeTrackItem>` shown by `InitiativeTrackComponent`; holds a mix of
  `Adventurer` and `EnemyGroup`. A group is added/removed automatically as enemies are added to or removed from it.
- `Enemies` — a `Task<List<Enemy>>` property that lazily fetches and caches all enemy JSON on first await.

Pages share state by injecting this service, not by passing parameters. `Adventurer` and `EnemyGroup` mutate their own
`CSSClass` to signal selection, which is how selection highlighting works.

### Enemy behaviour resolution

This is the core game mechanic and spans three files:

1. Each `wwwroot/enemy-data/*.json` file deserializes into `Enemy` with a list of `BehaviourChartColumn` — one column
   per situation (`Hidden`, `Engaged`, `In Cover`, `Close`, `Other`), each mapping d20 `RollRange` bands to an
   `ActionTaken` name.
2. `EnemyComponent.SetStatus` rolls a d20 via `IDiceRollService` (`Dice` is registered with 20 sides; it uses
   `RandomNumberGenerator` with rejection sampling for a fair roll) and calls `BehaviourChartColumn.GetStatus(roll)`
   to get the action name. Falls back to `"Confusion!"` if no band matches.
3. `ActionsService` loads `wwwroot/enemy-actions/enemy-actions.json` once and flattens it into an
   `Actions` dictionary keyed by action name, which supplies the rules text displayed to the player.

**Action names in enemy JSON must exactly match a `Name` in `enemy-actions.json`**, otherwise the description
resolves to empty and the player sees a blank rules panel.

### Adding an enemy

Add the JSON file to `wwwroot/enemy-data/`, then add a `const` **and** an array entry in `EnemyFileNameConstants`
(bottom of `Services/EnemyService.cs`). The array is declared with an explicit size (`new string[14]`) which must be
bumped too. Enemies are discovered only through that list — dropping a file in the folder is not enough.

### Styling

Sass in `Sass/` compiles to `wwwroot/css/site.css`; `style.scss` pulls in Bootstrap 4 from `node_modules` plus
`app.scss`. Edit the `.scss` sources, never `wwwroot/css/site.css` (generated, but committed).

## Known rough edges

- `BlazorApp.csproj` targets `net6.0`, which is out of support. It still **builds and runs** under the .NET 10 SDK
  (roll-forward), emitting `NETSDK1138`; no .NET 6 SDK install is needed.
- `dotnet test` does **not** work here: the test project compiles, but the testhost aborts with "You must install or
  update .NET to run this application" because no .NET 6 *runtime* is installed. Even with one,
  `Tests/JsonFilesTests.cs` hardcodes Windows paths (`C:\VisualStudio\...`) and `\` separators, so it would fail on
  macOS/Linux. (`Newtonsoft.Json` resolves transitively via the test SDK, so that part does compile.)
- `Components/ModalView .razor` hardcodes `aria-hidden="true"` on the modal root and never toggles it, so the enemy
  picker is invisible to the accessibility tree (and to `getByRole` in browser tests) even while displayed. Note the
  space in that filename.
- `ActionsService`'s constructor kicks off loading with `new Task(async () => ...)` + `RunSynchronously()`, which does
  not await the inner async work, so `Actions` can still be null when a component first reads it.
- `Pages/Counter.razor` / `CounterPageComponent` is leftover template scaffolding, unrelated to the game.
