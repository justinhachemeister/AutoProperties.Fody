﻿using System;
using System.Reflection;

using AutoProperties;

using TestLibrary;

// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local
// ReSharper disable PossibleNullReferenceException
// ReSharper disable AssignNullToNotNullAttribute

public class ClassWithSimpleInterceptors
{
    private int _field = 42;

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithGenericInterceptors
{
    private int _field = 42;

    [GetInterceptor]
    private T GetInterceptor<T>(string propertyName)
    {
        return (T)Convert.ChangeType(_field, typeof(T));
    }

    [SetInterceptor]
    private void SetInterceptor<T>(T value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithMixedInterceptors
{
    private int _field = 42;

    [GetInterceptor]
    private T GetInterceptor<T>(string propertyName)
    {
        return (T)Convert.ChangeType(_field, typeof(T));
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithExternalInterceptorsBase : ExternalInterceptorBase
{
    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithExternalGenericInterceptorsBase : ExternalInterceptorBaseWithGenerics
{
    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithInterceptorsUsingAllPossibleParameters
{
    private int _field = 42;

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType, PropertyInfo propertyInfo, FieldInfo fieldInfo)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName, Type propertyType, PropertyInfo propertyInfo, FieldInfo fieldInfo)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class BaseWithPrivateInterceptors
{
    private int _field = 42;

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }
}

public class DerivedFromBaseWithPrivateInterceptors : BaseWithPrivateInterceptors
{
    public DerivedFromBaseWithPrivateInterceptors()
    {
        Property1 = 7;
        Property2 = "8";
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithDoubleInterceptors
{
    private int _field = 42;

    public ClassWithDoubleInterceptors()
    {
        Property1 = 7;
        Property2 = "8";
    }

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [GetInterceptor]
    private object GetInterceptor2(string propertyName, Type propertyType)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithMissingGetInterceptor
{
    private int _field = 42;

    public ClassWithMissingGetInterceptor()
    {
        Property1 = 7;
        Property2 = "8";
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithBadGenericInterceptors
{
    private int _field = 42;

    public ClassWithBadGenericInterceptors()
    {
        Property1 = 7;
        Property2 = "8";
    }

    [GetInterceptor]
    private T GetInterceptor<T, T1>(string propertyName, T1 invalid)
    {
        return (T)Convert.ChangeType(_field, typeof(T));
    }

    [SetInterceptor]
    private void SetInterceptor<T, T1>(T value, string propertyName, T1 invalid)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}


public class ClassWithUnsupportedParameter
{
    private int _field = 42;

    public ClassWithUnsupportedParameter()
    {
        Property1 = 7;
        Property2 = "8";
    }

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType, int invalid)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; }

    public string Property2 { get; set; }
}

public class ClassWithInterceptorAndInitializedAutoProperties
{
    private int _field = 42;

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    public int Property1 { get; set; } = 7;

    public string Property2 { get; set; } = "8";
}

public class ClassWithInterceptorAndInitializedAutoPropertiesAndIgnoredPropties
{
    private int _field = 42;

    [GetInterceptor]
    private object GetInterceptor(string propertyName, Type propertyType)
    {
        return Convert.ChangeType(_field, propertyType);
    }

    [SetInterceptor]
    private void SetInterceptor(object value, string propertyName)
    {
        _field = Convert.ToInt32(value);
    }

    [InterceptIgnore]
    public int Property1 { get; set; } = 7;

    [InterceptIgnore]
    public string Property2 { get; set; } = "8";
}