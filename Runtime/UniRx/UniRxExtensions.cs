using System;
using UniRx;

namespace StrongExtensions
{
    public static class UniRxExtensions
    {
        public static IDisposable Subscribe(this IObservable<Unit> observable, Action onNext) =>
            observable.Subscribe(_ => onNext());
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
        
        public static IObserver<T> ToObserver<T>(this IReactiveCommand<T> command) =>
            Observer.Create((T value) => command.Execute(value));
        
        public static IObserver<T> ToObserver<T>(this ISubject<T> observable) =>
            Observer.Create((T value) => observable.OnNext(value));
    }
}
