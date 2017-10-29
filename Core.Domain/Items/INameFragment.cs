using System;


namespace Core.Domain.Items
{
    public interface INameFragment
    {
        string Text { get; }

        string WebAddress { get; }
    }
}