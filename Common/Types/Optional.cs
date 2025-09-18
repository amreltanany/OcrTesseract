using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCRApp.Common.Types
{
    internal class Optional<T>
    {
        //Property that returns true if there’s at least one element in value.
        public bool HasValue { get => value.Any(); }

        //A readonly field that stores the data.
        private readonly IEnumerable<T> value;

        private Optional(IEnumerable<T> value) => this.value = value;

        //If there’s a value, it calls onValue with that value.
        //Do performs an action only if a value exists.
        public void Do(Action<T> onValue) => value.ToList().ForEach(onValue);

        //Wraps the given value inside an array (new T[] { value }) which acts as the one-element sequence.
        public static Optional<T> Create(T value) => new Optional<T>(new T[] { value });

        //Returns an empty sequence (Array.Empty<T>()).
        public static Optional<T> Empty() => new Optional<T>(new T[0]);

        public static Optional<T> MaybeCreate(T? value) => value == null ? Empty() : Create(value);


    }
}
