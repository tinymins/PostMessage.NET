using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostMessage.NET.Avalonia.ViewModels
{
    public class MainWrapperViewModel : ViewModelBase
    {
        public MainWrapperViewModel() {
            Items = [""];
        }

        public string[] Items { get; } = Array.Empty<string>();
    }
}
