using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bridge.Html5;
using Bridge.Javascript;

namespace Bridge.Ractive.Example
{
    using Redux;

    public class App
    {
        public static void Main()
        {
            var initialState = new TodoAppState
            {
                DescriptionInput = "",
                Visibility = TodoVisibility.All,
                Todos = new Todo[]
                {
                    new Todo
                    {
                        Id = 0,
                        Description = "Have fun with Ractive and Redux",
                        IsCompleted = true
                    },
                    new Todo
                    {
                        Id = 1,
                        Description = "Make an awesome todo app",
                        IsCompleted = false
                    }
                }
            };

            var store = Redux.CreateStore(Todos.Reducer(initialState));

            Action<TodoVisibility> show = filter => store.Dispatch(new SetVisibility { Visibility = filter });

            // events that are attached to button clicks on the template
            var eventHandlers = new EventHandlers
            {
                ToggleTodo = id => store.Dispatch(new ToggleTodoCompleted { Id = id }),
                DeleteTodo = id => store.Dispatch(new DeleteTodo { Id = id }),
                AddTodo = () => store.Dispatch(new AddTodo { }),
                ShowAll = () => show(TodoVisibility.All),
                ShowComplete = () => show(TodoVisibility.Completed),
                ShowIncomplete = () => show(TodoVisibility.YetToComplete)
            };

            // functions that can be called in the template to compute smth directly
            var functions = new TemplateFunctions
            {
                Filter = (visibility, todos) => 
                {
                    if (visibility == TodoVisibility.Completed)
                        return todos.Where(todo => todo.IsCompleted).ToArray();
                    if (visibility == TodoVisibility.YetToComplete)
                        return todos.Where(todo => !todo.IsCompleted).ToArray();
                    return todos;
                }
            };

            
            var ractive = new Ractive(new RactiveOptions
            {
                Element = "#app",
                Template = "#app-template",
                Data = JS.Merge(initialState, functions)
            });

            // although two-way binding is available in Ractive, 
            // I will use a vanilla handler to make data-flow one directional
            ractive.Find("#txtAddTodo").OnTextChanged(input =>
            {
                store.Dispatch(new UpdateDescriptionInput { Description = input });
            });

            // attach the events
            ractive.On(eventHandlers);

            store.Subscribe(() =>
            {
                var state = store.GetState();
                ractive.Set(JS.Merge(state, functions));
            });
        }
    }
}
