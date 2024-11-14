using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace System
{
    /// <summary>
    /// Represents a custom queue type
    /// </summary>
    /// <typeparam name="T">The type of the items in the queue</typeparam>
    [ExcludeFromCodeCoverage]
    public class EventQueue<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventQueue{T}"/> class
        /// </summary>
        public EventQueue()
        {
            _queue = new Queue<T>();
        }

        private readonly Queue<T> _queue;

        /// <summary>
        /// Event is raised when an item is added to the queue
        /// </summary>
        public event EventHandler Added;

        /// <summary>
        /// Event that is raised when an item is removed from the queue
        /// </summary>
        public event EventHandler Removed;

        /// <summary>
        /// Gets the amount of items in the queue
        /// </summary>
        public int Count => _queue.Count;

        /// <summary>
        ///
        /// </summary>
        protected virtual void OnAdded() => Added?.Invoke(this, EventArgs.Empty);

        /// <summary>
        ///
        /// </summary>
        protected virtual void OnRemoved() => Removed?.Invoke(this, EventArgs.Empty);

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        public virtual void Enqueue(T item)
        {
            _queue.Enqueue(item);
            this.OnAdded();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual T Dequeue()
        {
            T item = _queue.Dequeue();
            this.OnRemoved();
            return item;
        }

    }
}