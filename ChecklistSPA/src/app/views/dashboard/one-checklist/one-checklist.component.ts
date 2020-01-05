import { Component, OnInit } from '@angular/core';
import { DashboardService } from 'src/app/services/dashboard.service';
import { ActivatedRoute } from '@angular/router';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-one-checklist',
  templateUrl: './one-checklist.component.html',
  styleUrls: ['./one-checklist.component.sass']
})
export class OneChecklistComponent implements OnInit {

  constructor(private dashboardService: DashboardService, private router: ActivatedRoute) { }

  userChecklist$ = this.dashboardService.userChecklist$.pipe(
    map((value: []) => {
      if (!value) {
        return null;
      }
      return value.find((element: any) => element.id === +this.router.snapshot.paramMap.get('id'));
  }));

  ngOnInit() {
  }

}
