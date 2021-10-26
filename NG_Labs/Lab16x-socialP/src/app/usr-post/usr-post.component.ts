import { Component, Input, OnInit } from '@angular/core';
import { IusrPost } from '../iusr-post';

@Component({
  selector: 'app-usr-post',
  templateUrl: './usr-post.component.html',
  styleUrls: ['./usr-post.component.css']
})
export class UsrPostComponent implements OnInit {


  @Input() post: IusrPost = {

    title: "",
    posted: "",
    thought:""

  };


  constructor() {

   }

  





  ngOnInit(): void {
  }

}
