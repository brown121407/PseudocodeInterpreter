using System;
using System.Collections.Generic;
using System.Linq;
using PseudocodeInterpreter.Exceptions;
using PseudocodeInterpreter.Objects;

namespace PseudocodeInterpreter
{
	class ScopeStack
	{
		public class Scope
		{
			public Dictionary<string, Literal> Variables { get; private set; }

			public Scope()
			{
				Variables = new Dictionary<string, Literal>();
			}
		}

		private List<Scope> _scopes;

		public ScopeStack()
		{
			_scopes = new List<Scope>();
		}

		public void Push()
		{
			_scopes.Add(new Scope());
		}

		public void Pop()
		{
			if (_scopes.Any())
			{
				_scopes.RemoveAt(_scopes.Count - 1);
			}
		}

		public void CreateVariable(string name, Literal value)
		{
			_scopes.Last().Variables.Add(name, value);
		}

		public Literal GetVar(string name)
		{
		    for (int i = _scopes.Count - 1; i >= 0; i--)
            {
				if (_scopes[i].Variables.ContainsKey(name))
				{
					return _scopes[i].Variables[name];
				}
			}

			return null;
		}

		public void SetVar(string name, Literal value)
		{
		    for (int i = _scopes.Count - 1; i >= 0; i--)
		    {
		        if (_scopes[i].Variables.ContainsKey(name))
		        {
		            _scopes[i].Variables[name] = value;
                    return;
		        }
		    }
			
			throw new Exception(ErrorMessages.UndefinedSymbol(name));
		}

		public bool DoesVariableExist(string name)
		{
		    for (int i = _scopes.Count - 1; i >= 0; i--)
		    {
		        if (_scopes[i].Variables.ContainsKey(name))
		        {
		            return true;
		        }
		    }

            return false;
		}

	}
}
