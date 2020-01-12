import { Component, OnInit, Inject } from '@angular/core';
import { MAT_SNACK_BAR_DATA } from '@angular/material/snack-bar';

@Component({
  selector: 'app-allert-message',
  templateUrl: './allert-message.component.html',
  styleUrls: ['./allert-message.component.sass']
})
export class AllertMessageComponent{

  constructor(@Inject(MAT_SNACK_BAR_DATA) public data: any) { }

}
