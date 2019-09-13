using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Gibbed.MassEffect2.FileFormats {
    public class BitArrayWrapper : IList {
        private BitArray array;
        public bool Item { get; private set; } // for CollectionEditor, so it knows the correct Item type

        public BitArrayWrapper()
            : this(null) {
        }

        public BitArrayWrapper(BitArray array) {
            this.array = array;
        }

        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator() {
            return this.array.GetEnumerator();
        }
        #endregion

        #region IList Members
        int IList.Add(object value) {
            if ((value is bool) == false) {
                throw new System.ArgumentException("value");
            }

            var index = this.array.Length;
            this.array.Length++;
            this.array[index] = (bool)value;
            return index;
        }

        void IList.Clear() {
            this.array.Length = 0;
        }

        bool IList.Contains(object value) {
            throw new System.NotSupportedException();
        }

        int IList.IndexOf(object value) {
            throw new System.NotSupportedException();
        }

        void IList.Insert(int index, object value) {
            if ((value is bool) == false) {
                throw new System.ArgumentException("value");
            }

            if (index >= this.array.Length) {
                this.array.Length = index + 1;
                this.array[index] = (bool)value;
            } else {
                this.array.Length++;
                for (int i = this.array.Length - 1; i > index; i--) {
                    this.array[i] = this.array[i - 1];
                }
                this.array[index] = (bool)value;
            }
        }

        bool IList.IsFixedSize {
            get { return false; }
        }

        bool IList.IsReadOnly {
            get { return false; }
        }

        void IList.Remove(object value) {
            throw new System.NotSupportedException();
        }

        void IList.RemoveAt(int index) {
            if (index >= this.array.Length) {
                throw new System.IndexOutOfRangeException();
            }

            for (int i = this.array.Length - 1; i > index; i--) {
                this.array[i - 1] = this.array[i];
            }
            this.array.Length--;
        }

        object IList.this[int index] {
            get { return this.array[index]; }
            set {
                if ((value is bool) == false) {
                    throw new System.ArgumentException("value");
                }

                this.array[index] = (bool)value;
            }
        }
        #endregion

        #region ICollection Members
        void ICollection.CopyTo(System.Array array, int index) {
            for (int i = 0; i < this.array.Length; i++) {
                array.SetValue(this.array[i], index + i);
            }
        }

        int ICollection.Count {
            get { return this.array.Length; }
        }

        bool ICollection.IsSynchronized {
            get { return false; }
        }

        object ICollection.SyncRoot {
            get { return this; }
        }
        #endregion
    }
}