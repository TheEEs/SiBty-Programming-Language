using System;
namespace Planguage {
	namespace Errors {
	    class BaseError : System.Exception {
			public virtual string message() {
				throw new System.NotImplementedException();
			}
		}

		class TypeCastingError : BaseError { }

		class NilClassException : BaseError { }

		class OperatorError : BaseError { }

		class IdentifierError : BaseError {
			string id;
			public IdentifierError(string id) {
				this.id = id;
			}
            public override string message()
            {
                return this.id;
            }
        }

		class VariableError : BaseError {
            string var_name;
            public VariableError(string var_name = "")
            {
                this.var_name = var_name;
            }
            public override string message()
            {
                return this.var_name;
            }
        }

		class ParameterError : BaseError {
			public bool is_less_than = false;
			public ParameterError(bool is_less_than) {
				this.is_less_than = is_less_than;
			}
		}
	}
}