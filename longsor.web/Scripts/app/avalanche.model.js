(function (ko, datacontext) {

    datacontext.Avalanche = Avalanche;
    datacontext.AvalancheList = AvalancheList;
    
    function Avalanche(data) {
        var self = this;
        data = data || {};
        
        // Persisted properties
        self.Id = data.id;
        self.Title = ko.observable(data.title);
        self.Description = ko.observable(data.Description);
        self.ParentAvalanches = ko.observableArray(data.ParentAvalanches);
        self.Avalanches = ko.observableArray(data.Avalanches);
        self.Solutions = ko.observableArray(data.Solutions);
        
        // Non-persisted properties
        self.ErrorMessage = ko.observable();

        self.save = function () { return datacontext.saveChangedAvalanche(self); };
        
        // Auto-save when these properties change
        self.Title.subscribe(self.save);
        self.Description.subscribe(self.save);
    }

    function AvalancheList(data) {
        var self = this;
        data = data || {};
        
        // Persisted properties
        self.Avalanches = ko.observableArray(importAvalancheItems(data.Avalanches));

        // Non-persisted properties
        self.ErrorMessage = ko.observable();

        self.save = function () { return datacontext.saveChangedAvalancheList(self); };
    }

    function TodoList(data) {
        var self = this;
        data = data || {};

        // Persisted properties
        self.TodoListId = data.TodoListId;
        self.UserId = data.UserId || "to be replaced";
        self.Title = ko.observable(data.Title || "My todos");
        self.Todos = ko.observableArray(importTodoItems(data.Todos));

        // Non-persisted properties
        self.IsEditingListTitle = ko.observable(false);
        self.NewTodoTitle = ko.observable();
        self.ErrorMessage = ko.observable();

        self.save = function () { return datacontext.saveChangedTodoList(self); };
        self.deleteTodo = function () {
            var todoItem = this;
            return datacontext.deleteTodoItem(todoItem)
                 .done(function () { self.Todos.remove(todoItem); });
        };

        // Auto-save when these properties change
        self.Title.subscribe(self.save);

    };
    // convert raw todoItem data objects into array of TodoItems
    function importTodoItems(todoItems) {
        return $.map(todoItems || [],
                function (todoItemData) {
                    return datacontext.createTodoItem(todoItemData);
                });
    }
    TodoList.prototype.addTodo = function () {
        var self = this;
        if (self.NewTodoTitle()) { // need a title to save
            var todoItem = datacontext.createTodoItem(
                {
                    Title: self.NewTodoTitle(),
                    TodoListId: self.TodoListId
                });
            self.Todos.push(todoItem);
            datacontext.saveNewTodoItem(todoItem);
            self.NewTodoTitle("");
        }
    };

})(ko, todoApp.datacontext);
