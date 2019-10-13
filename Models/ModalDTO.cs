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
        private Action _action;
        public T Data { get; set; }
        public EventCallback<MouseEventArgs> EventCallback { get; set; }
        public string ShowModal { get; set; } = "";       

        public ModalDTO(Action stateChange, T data)
        {
            Data = data;
            EventCallback = new EventCallback<MouseEventArgs>(this, stateChange);
            _action = stateChange;
            SetShowModal();
        }             

        public async Task HandleEventAsync(EventCallbackWorkItem item, object arg)
        {   
            SetShowModal();
            await item.InvokeAsync(arg);
            _action.Invoke();
            
        }

        private void SetShowModal()
        {
            ShowModal = String.IsNullOrEmpty(ShowModal) ? "show" : "";
        }
    }
}
