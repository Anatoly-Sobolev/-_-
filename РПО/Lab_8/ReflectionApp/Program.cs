using System;
using System.IO;
using System.Reflection;

namespace ReflectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllPath = Path.Combine(AppContext.BaseDirectory, "ReflectionLibrary.dll");
            Assembly assembly = Assembly.LoadFrom(dllPath);
            Type studentType = assembly.GetType("ReflectionLibrary.Student");

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;

            Console.WriteLine("Загружена библиотека: " + assembly.GetName().Name);
            Console.WriteLine("Класс: " + studentType.FullName);
            Console.WriteLine();

            PrintFields(studentType, flags);
            PrintProperties(studentType, flags);
            PrintMethods(studentType, flags);

            object student = Activator.CreateInstance(studentType);

            Console.WriteLine("Значения полей:");
            FieldInfo[] fields = studentType.GetFields(flags);
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i].Name + " = " + fields[i].GetValue(student));
            }
            Console.WriteLine();

            Console.WriteLine("Значения свойств:");
            PropertyInfo[] properties = studentType.GetProperties(flags);
            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine(properties[i].Name + " = " + properties[i].GetValue(student));
            }
            Console.WriteLine();

            SetFields(student, fields);
            SetProperties(student, properties);

            Console.WriteLine("После изменения значений:");
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i].Name + " = " + fields[i].GetValue(student));
            }
            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine(properties[i].Name + " = " + properties[i].GetValue(student));
            }
            Console.WriteLine();

            Console.WriteLine("Вызов методов:");
            MethodInfo[] methods = studentType.GetMethods(flags | BindingFlags.DeclaredOnly);
            for (int i = 0; i < methods.Length; i++)
            {
                if (!methods[i].IsSpecialName && methods[i].GetParameters().Length == 0)
                {
                    object result = methods[i].Invoke(student, null);
                    Console.WriteLine(methods[i].Name + ": " + result);
                }
            }
            Console.WriteLine();

            Console.WriteLine("Вызов конструкторов:");
            ConstructorInfo[] constructors = studentType.GetConstructors(flags);
            for (int i = 0; i < constructors.Length; i++)
            {
                ParameterInfo[] parameters = constructors[i].GetParameters();
                object createdObject;

                if (parameters.Length == 0)
                {
                    createdObject = constructors[i].Invoke(null);
                }
                else
                {
                    object[] values = new object[] { "Иван", 20, 4.8 };
                    createdObject = constructors[i].Invoke(values);
                }

                FieldInfo publicField = studentType.GetField("PublicField", flags);
                Console.WriteLine("Создан объект, PublicField = " + publicField.GetValue(createdObject));
            }
        }

        static void PrintFields(Type studentType, BindingFlags flags)
        {
            Console.WriteLine("Поля:");
            FieldInfo[] fields = studentType.GetFields(flags);
            for (int i = 0; i < fields.Length; i++)
            {
                Console.WriteLine(fields[i].Name + " - " + fields[i].FieldType.Name);
            }
            Console.WriteLine();
        }

        static void PrintProperties(Type studentType, BindingFlags flags)
        {
            Console.WriteLine("Свойства:");
            PropertyInfo[] properties = studentType.GetProperties(flags);
            for (int i = 0; i < properties.Length; i++)
            {
                Console.WriteLine(properties[i].Name + " - " + properties[i].PropertyType.Name);
            }
            Console.WriteLine();
        }

        static void PrintMethods(Type studentType, BindingFlags flags)
        {
            Console.WriteLine("Методы:");
            MethodInfo[] methods = studentType.GetMethods(flags | BindingFlags.DeclaredOnly);
            for (int i = 0; i < methods.Length; i++)
            {
                if (!methods[i].IsSpecialName)
                {
                    Console.WriteLine(methods[i].Name + " - " + methods[i].ReturnType.Name);
                }
            }
            Console.WriteLine();
        }

        static void SetFields(object student, FieldInfo[] fields)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].FieldType == typeof(string))
                {
                    fields[i].SetValue(student, "Петр");
                }
                if (fields[i].FieldType == typeof(int))
                {
                    fields[i].SetValue(student, 21);
                }
                if (fields[i].FieldType == typeof(double))
                {
                    fields[i].SetValue(student, 5.0);
                }
            }
        }

        static void SetProperties(object student, PropertyInfo[] properties)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i].PropertyType == typeof(string))
                {
                    properties[i].SetValue(student, "Новое значение");
                }
                if (properties[i].PropertyType == typeof(int))
                {
                    properties[i].SetValue(student, 30);
                }
                if (properties[i].PropertyType == typeof(double))
                {
                    properties[i].SetValue(student, 3.7);
                }
            }
        }
    }
}
