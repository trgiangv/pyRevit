using System;

namespace pyRevitLabs.DeffrelDB {
    public class DeffrelDBException : Exception {
        public DeffrelDBException() { }

        public DeffrelDBException(string message) : base(message) { }

        public DeffrelDBException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class AccessRestrictedException : DeffrelDBException {
        public AccessRestrictedException() { }

        public AccessRestrictedException(ConnectionLock newLock, ConnectionLock restrictingLock) {
            NewLock = newLock;
            RestrictingLock = restrictingLock;
        }

        public ConnectionLock NewLock { get; set; }
        public ConnectionLock RestrictingLock { get; set; }

        public override string Message {
            get {
                return $"Requested lock {NewLock} is restricted by {RestrictingLock}";
            }
        }
    }

    public class AccessRestrictedByExistingLockException : DeffrelDBException {
        public AccessRestrictedByExistingLockException() { }

        public AccessRestrictedByExistingLockException(ConnectionLock newLock, ConnectionLock restrictingLock) {
            NewLock = newLock;
            RestrictingLock = restrictingLock;
        }

        public ConnectionLock NewLock { get; set; }
        public ConnectionLock RestrictingLock { get; set; }

        public override string Message {
            get {
                return $"Requested lock {NewLock} is not on the same path as active connection lock" +
                       $" {RestrictingLock}. Active lock must be released first.";
            }
        }
    }


}
