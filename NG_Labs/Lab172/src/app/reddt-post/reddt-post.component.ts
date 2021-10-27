import { Component, Input, OnInit } from '@angular/core';
import { ReddtChildObj, ReddtDataObj } from '../reddt-data-obj';
import { HttpClient } from '@angular/common/http'; 


@Component({
  selector: 'app-reddt-post',
  templateUrl: './reddt-post.component.html',
  styleUrls: ['./reddt-post.component.css']
})
export class ReddtPostComponent implements OnInit {


  @Input() post?: ReddtChildObj;







  constructor() { 

    console.log(this.post);



  }

  ngOnInit(): void {
  }

}
