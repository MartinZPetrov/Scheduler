﻿using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Scheduler.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Scheduler.ViewModel
{
    public class CommandVM
    {
        public string CommandDisplay { get; set; }
        public CommandMessage Message { get; set; }
        public RelayCommand Send { get; private set; }
        public Geometry IconGeometry { get; set; }
        public CommandVM()
        {
            Send = new RelayCommand(SendExecute);
        }
        private void SendExecute()
        {
            Messenger.Default.Send<CommandMessage>(Message);
        }
    }
}
