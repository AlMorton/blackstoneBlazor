using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class ModalDTO<T> : IHandleEvent
    {
        public T Data { get; set; }
        public EventCallback<MouseEventArgs> EventCallback { get; set; }
        public string ShowModal { get; set; } = "";

        public ModalDTO(Action<T> action)
        {            
            EventCallback = new EventCallback<MouseEventArgs>(this, action);
        }

        public void ToggleModal(T data)
        {
            Data = data;
            ShowModal = String.IsNullOrEmpty(ShowModal) ? "show" : "";
        }

        public async Task HandleEventAsync(EventCallbackWorkItem item, object arg)
        {
            await item.InvokeAsync(arg);            
        }
    }
}
