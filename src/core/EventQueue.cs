using System.Collections.Generic;

namespace System
{
    /// <summary>
    /// Represents a custom queue type
    /// </summary>
    /// <typeparam name="T">The type of the items in the queue</typeparam>
    public class EventQueue<T>
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="EventQueue"/> class
        /// </summary>
        public EventQueue()
        {
            this._queue = new Queue<T>();
        }

        #endregion Constructor

        #region Properties

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
        public int Count
        {
            get
            {
                return _queue.Count;
            }
        }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        protected virtual void OnAdded()
        {
            if (Added != null)
                Added(this, EventArgs.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        protected virtual void OnRemoved()
        {
            if (Removed != null)
                Removed(this, EventArgs.Empty);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="item"></param>
        public virtual void Enqueue(T item)
        {
            _queue.Enqueue(item);
            OnAdded();
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public virtual T Dequeue()
        {
            T item = _queue.Dequeue();
            OnRemoved();
            return item;
        }

        #endregion Methods
    }
}