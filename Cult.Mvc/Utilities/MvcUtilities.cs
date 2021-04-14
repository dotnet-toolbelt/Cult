﻿using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
// ReSharper disable UnusedMember.Global

namespace Cult.Mvc.Utilities
{
    public static class MvcUtilities
    {
        public static IEnumerable<ControllerInfo> GetControllersInfo(Assembly assembly = null)
        {
            var asm = assembly ?? Assembly.GetExecutingAssembly();
            var info = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                .Select(x => new ControllerActionInfo
                {
                    AreaName = x.DeclaringType?.CustomAttributes.FirstOrDefault(c => c.AttributeType == typeof(AreaAttribute))?.ConstructorArguments[0].Value?.ToString(),
                    Namespace = x.DeclaringType?.Namespace,
                    ControllerName = x.DeclaringType?.Name,
                    ActionName = x.Name,
                    ActionReturnType = x.ReturnType,
                    ActionAttributes = x.GetCustomAttributes(),
                    ControllerAttributes = x.DeclaringType?.GetCustomAttributes()
                })
                .OrderBy(x => x.ControllerName).ThenBy(x => x.ActionName).ToList()
                ;
            return MapToControllerInfos(info);
        }

        private static IEnumerable<ControllerInfo> MapToControllerInfos(List<ControllerActionInfo> controllerActionInfos)
        {
            var result = new List<ControllerInfo>();

            foreach (var item in controllerActionInfos)
            {
                var current = result.FirstOrDefault(x =>
                    x != null && x.Name == item.ControllerName && x.AreaName == item.AreaName && x.Namespace == item.Namespace);
                if (current != null)
                {
                    if (current.Actions.Any())
                    {
                        current.Actions.Add(new()
                        {
                            Attributes = item.ActionAttributes.ToList(),
                            ActionReturnType = item.ActionReturnType,
                            Name = item.ActionName
                        });
                    }
                    else
                    {
                        var actions = new List<ActionInfo>
                        {
                            new()
                            {
                                Attributes = item.ActionAttributes.ToList(),
                                ActionReturnType = item.ActionReturnType,
                                Name = item.ActionName
                            }
                        };
                        current.Actions = actions;
                    }
                }
                else
                {
                    var ctrl = new ControllerInfo
                    {
                        Name = item.ControllerName,
                        AreaName = item.AreaName,
                        Namespace = item.Namespace,
                        Attributes = item.ControllerAttributes.ToList()
                    };

                    var actions = new List<ActionInfo>
                    {
                        new()
                        {
                            Attributes = item.ActionAttributes.ToList(),
                            ActionReturnType = item.ActionReturnType,
                            Name = item.ActionName
                        }
                    };
                    ctrl.Actions = actions;
                    result.Add(ctrl);
                }
            }

            return result;
        }
    }
}
