using System;
using UniRx;

namespace StrongExtensions
{
    public static class UniRxExtensions
    {
        public static void Send<T>(this IObserver<T> observable, T arg, bool when) =>
            observable.With(x => x.OnNext(arg), when);

        public static void Send(this IObserver<Unit> observable, bool when) =>
            observable.With(x => x.OnNext(Unit.Default), when);

        public static void Send<T>(this IObserver<T> observable, T arg, Func<bool> when) =>
            observable.With(x => x.OnNext(arg), when);

        public static void Send(this IObserver<Unit> observable, Func<bool> when) =>
            observable.With(x => x.OnNext(Unit.Default), when);

        public static void Send(this IObserver<Unit> observable) =>
            observable.With(x => x.OnNext(Unit.Default));

        public static IObserver<T> ToObserver<T>(this IReactiveProperty<T> reactiveProperty) =>
            Observer.Create((T value) => reactiveProperty.Value = value);
    }
}
