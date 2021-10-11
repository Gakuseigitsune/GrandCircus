import { Component, OnInit } from '@angular/core';
import { Todo } from '../todo';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css']
})
export class TodoListComponent implements OnInit{

  TaskName: string;

  TaskItems: Todo[] =[

    {task: 'code stuff', completed: true},
    {task: 'debug code', completed: false},
    {task: 'fix code', completed: false},
    {task: 'test code', completed: false},
    {task: 'revise code', completed: false}

  ];

  get allComplete(): boolean{

    return !this.TaskItems.some(task => !task.completed); 

    };


  

  newTaskName: string = '';

  constructor() { 

    this.TaskName = "new task group"



  }

  ngOnInit(): void {
  }

  completeTask(todo: Todo){

    todo.completed = true;
  }

  addTask(){
    if(this.newTaskName == '') return;
    this.TaskItems.push({task: this.newTaskName, completed: false});
    this.newTaskName='';
  }



 

}
