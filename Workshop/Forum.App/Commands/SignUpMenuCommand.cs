﻿using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;


namespace Forum.App.Commands
{
    public class SignUpMenuCommand : ICommand
    {
        private IMenuFactory menuFactory;
        public IMenu Execute(params string[] args)
        {

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);
            return menu;
        }

        public SignUpMenuCommand(IMenuFactory menuFactory)
        {
            this.menuFactory = menuFactory;
        }
    }
}