using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using ReactiveUI;
using ReactiveUI.Winforms;

namespace ReactiveUIDemo;

public class ListBoxItemConverter : IBindingTypeConverter
{
    public int GetAffinityForObjects(Type fromType, Type toType)
    {
        if (toType != typeof(Control.ControlCollection))
        {
            return 0;
        }

        if (fromType.GetInterface("IEnumerable") == null)
        {
            return 0;
        }

        return 10;
    }

    public bool TryConvert(object @from, Type toType, object conversionHint, out object result)
    {
        var enumerable = (IEnumerable)from;

        if (enumerable == null)
        {
            result = null;
            return false;
        }

        var viewModelControlHosts = new List<ViewModelControlHost>();

        foreach (var viewModel in enumerable)
        {
            viewModelControlHosts.Add(new ViewModelControlHost { ViewModel = viewModel, Dock = DockStyle.Top });
        }
            
        result = viewModelControlHosts;
        return true;
    }
}
