using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Gate.Simulator.Core
{
    internal sealed class DisposableEntry : IDisposable
    {
        private readonly Action disposal;

        internal DisposableEntry(Action disposal)
        {
            this.disposal = disposal;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool isDisposed = false;
        private void Dispose(bool disposing)
        {
            if (disposing && !isDisposed)
            {
                disposal();
                isDisposed = true;
            }
        }
    }

    public static class Disposable
    {
        public static IDisposable Create<TEntry, TKey>(IDictionary<TKey,TEntry> registered, TKey key)
        {
            return new DisposableEntry(() =>
            {
                if (registered.ContainsKey(key))
                {
                    registered.Remove(key);
                }
            });
        }
        public static IDisposable Create(Action disposal)
        {
            return new DisposableEntry(disposal);
        }
    }
}
