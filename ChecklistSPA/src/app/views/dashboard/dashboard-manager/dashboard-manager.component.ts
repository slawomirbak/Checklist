import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-dashboard-manager',
  templateUrl: './dashboard-manager.component.html',
  styleUrls: ['./dashboard-manager.component.sass']
})
export class DashboardManagerComponent implements OnInit {

  createsList = false;

  constructor() { }

  ngOnInit() {
  }
  createNewList(){
    this.createsList = true;
  }
  showList(){
    this.createsList = false;
  }
}
