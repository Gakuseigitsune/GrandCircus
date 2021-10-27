import { Component, Input, OnInit } from '@angular/core';
import { ReddtDataObj, ReddtObj } from '../reddt-data-obj';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Component({
  selector: 'app-reddt-post-list',
  templateUrl: './reddt-post-list.component.html',
  styleUrls: ['./reddt-post-list.component.css']
})

export class ReddtPostListComponent implements OnInit {

  ReddtList?: ReddtObj;
  postCount: number = 0;



  constructor(private http: HttpClient) {

    this.http.get<any>('https://reddit.com/r/aww/.json').subscribe(

    (result: ReddtObj) =>{ 

      this.ReddtList = result;
      this.postCount = this.ReddtList.data.children.length;
      console.log(`list loaded! ${this.postCount} posts found`);

    }

    ); 

   }

  ngOnInit(): void {
  }

  manualGetPosts(){

    this.http.get<any>('https://reddit.com/r/aww/.json').subscribe(

    (result: ReddtObj) =>{ 

      this.ReddtList = result;
      this.postCount = this.ReddtList.data.children.length;
      console.log(`list loaded! ${this.postCount} posts found`);

    }

    ); 






  }




  

}
