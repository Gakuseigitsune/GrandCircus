import { Component, OnInit } from '@angular/core';
import { IusrPost } from '../iusr-post';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-post-list',
  templateUrl: './post-list.component.html',
  styleUrls: ['./post-list.component.css']
})
export class PostListComponent implements OnInit {


  AllPosts: IusrPost[] = [

    {title: "Test post",              posted: new Date().toString(), thought: "this is a test"                 },
    {title: "Angular is fun",         posted: new Date().toString(), thought: "it's really neat!"              },
    {title: "a new angle on angular", posted: new Date().toString(), thought: "looks complicated but worth it!"},
    {title: "What about MVC",         posted: new Date().toString(), thought: "I miss it"                      },
    {title: "another tester",         posted: new Date().toString(), thought: "this is another test"           },
    {title: "testing 123",            posted: new Date().toString(), thought: "echo 456"                       }

  ];

  newTitle: string = "";
  newThought: string ="";

  constructor() { }

newPost(){

  this.AllPosts.push({title: this.newTitle, posted: new Date().toString(), thought: this.newThought})
}

deletePost(aPost: IusrPost){ this.AllPosts.splice(this.AllPosts.indexOf(aPost), 1); }


  ngOnInit(): void {
  }

}
