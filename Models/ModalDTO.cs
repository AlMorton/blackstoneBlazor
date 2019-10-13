﻿using Microsoft.AspNetCore.Components;
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
        private Action _stateChange;

        public ModalDTO(Action stateChange)
        {
            _stateChange = stateChange;
            EventCallback = new EventCallback<MouseEventArgs>(this, stateChange);
        }
        public void ToggleModal(T data)
        {
            Data = data;
            SetShowModal();
        }        

        public async Task HandleEventAsync(EventCallbackWorkItem item, object arg)
        {         
            SetShowModal();
            await item.InvokeAsync(arg);        
        }

        public void SetShowModal()
        {
            ShowModal = String.IsNullOrEmpty(ShowModal) ? "show" : "";
        }
    }
}
