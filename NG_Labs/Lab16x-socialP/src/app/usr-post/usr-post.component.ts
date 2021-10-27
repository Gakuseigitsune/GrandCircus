import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
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

  @Output() remove: EventEmitter<IusrPost> = new EventEmitter<IusrPost>();


  constructor(){}

  rm_post(){

    this.remove.emit(this.post);

  }



   

  





  ngOnInit(): void {
  }

}
