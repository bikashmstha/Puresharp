﻿using System;
using Mono;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Collections;
using Mono.Collections.Generic;
using Puresharp;
using Puresharp.Discovery;

using ConstructorInfo = System.Reflection.ConstructorInfo;
using MethodInfo = System.Reflection.MethodInfo;
using FieldInfo = System.Reflection.FieldInfo;

namespace Mono.Cecil
{
    static internal class __MethodBody
    {
        static private readonly MethodInfo GetTypeFromHandle = Puresharp.Discovery.Metadata.Method(() => Type.GetTypeFromHandle(Argument<RuntimeTypeHandle>.Value));
        static private readonly MethodInfo GetMethodFromHandle = Puresharp.Discovery.Metadata.Method(() => MethodInfo.GetMethodFromHandle(Argument<RuntimeMethodHandle>.Value, Argument<RuntimeTypeHandle>.Value));

        static public int Add(this MethodBody body, Mono.Cecil.Cil.Instruction instruction)
        {
            body.Instructions.Add(instruction);
            var _branch = Branch.Query(body);
            if (_branch == null) { return body.Instructions.Count - 1; }
            _branch.Finialize(instruction);
            return body.Instructions.Count - 1;
        }

        static public IDisposable True(this MethodBody body)
        {
            return new Branch(body, OpCodes.Brfalse).Begin();
        }

        static public IDisposable False(this MethodBody body)
        {
            return new Branch(body, OpCodes.Brtrue).Begin();
        }

        static public IDisposable Lock(this MethodBody body, FieldInfo field)
        {
            return new Lock(body, body.Method.Module.Import(field));
        }

        static public IDisposable Lock(this MethodBody body, FieldReference field)
        {
            return new Lock(body, field);
        }

        static public int Emit(this MethodBody body, Instruction instruction)
        {
            return body.Add(instruction);
        }

        static public int Emit(this MethodBody body, OpCode instruction)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction));
        }

        static public int Emit(this MethodBody body, OpCode instruction, Mono.Cecil.Cil.Instruction label)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, label));
        }

        static public int Emit(this MethodBody body, OpCode instruction, VariableDefinition variable)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, variable));
        }

        static public int Emit(this MethodBody body, OpCode instruction, FieldInfo field)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, body.Method.DeclaringType.Module.Import(field)));
        }

        static public int Emit(this MethodBody body, OpCode instruction, MethodInfo method)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, body.Method.DeclaringType.Module.Import(method)));
        }

        static public int Emit(this MethodBody body, OpCode instruction, TypeReference type, Mono.Collections.Generic.Collection<ParameterDefinition> parameters)
        {
            if (instruction == OpCodes.Calli)
            {
                var _signature = new CallSite(type);
                foreach (var _parameter in parameters) { _signature.Parameters.Add(_parameter); }
                _signature.CallingConvention = MethodCallingConvention.Default;
                return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, _signature));
            }
            throw new InvalidOperationException();
        }

        static public int Emit(this MethodBody body, OpCode instruction, TypeReference type)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, type));
        }

        static public int Emit(this MethodBody body, OpCode instruction, Type type)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, body.Method.Module.Import(type)));
        }

        static public int Emit(this MethodBody body, OpCode instruction, MethodReference method)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, method));
        }

        static public int Emit(this MethodBody body, OpCode instruction, FieldReference field)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, field));
        }

        static public int Emit(this MethodBody body, OpCode instruction, ParameterDefinition parameter)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, parameter));
        }

        static public int Emit(this MethodBody body, OpCode instruction, int operand)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, operand));
        }

        static public int Emit(this MethodBody body, OpCode instruction, string operand)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, operand));
        }

        static public int Emit(this MethodBody body, OpCode instruction, ConstructorInfo constructor)
        {
            return body.Add(Mono.Cecil.Cil.Instruction.Create(instruction, body.Method.DeclaringType.Module.Import(constructor)));
        }

        static public int Emit(this MethodBody body, Type type)
        {
            return body.Emit(body.Method.DeclaringType.Module.Import(type));
        }

        static public int Emit(this MethodBody body, TypeReference type)
        {
            body.Emit(OpCodes.Ldtoken, type);
            return body.Emit(OpCodes.Call, __MethodBody.GetTypeFromHandle);
        }

        static public int Emit(this MethodBody body, MethodInfo method)
        {
            return body.Emit(body.Method.DeclaringType.Module.Import(method));
        }

        static public int Emit(this MethodBody body, MethodReference method)
        {
            body.Emit(OpCodes.Ldtoken, method);
            body.Emit(OpCodes.Ldtoken, method.DeclaringType);
            return body.Emit(OpCodes.Call, __MethodBody.GetMethodFromHandle);
        }

        static public VariableDefinition Variable<T>(this MethodBody body)
        {
            var _variable = new VariableDefinition(string.Concat("<", Metadata<T>.Type, ">"), body.Method.DeclaringType.Module.Import(Metadata<T>.Type));
            body.Variables.Add(_variable);
            return _variable;
        }

        static public VariableDefinition Variable<T>(this MethodBody body, string name)
        {
            var _variable = new VariableDefinition(name, body.Method.DeclaringType.Module.Import(Metadata<T>.Type));
            body.Variables.Add(_variable);
            return _variable;
        }

        static public VariableDefinition Add(this MethodBody body, VariableDefinition variable)
        {
            body.Variables.Add(variable);
            return variable;
        }
    }
}
