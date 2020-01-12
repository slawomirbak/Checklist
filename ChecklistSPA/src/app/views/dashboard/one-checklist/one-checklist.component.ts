import { Component, OnInit, ViewChild } from '@angular/core';
import { DashboardService } from 'src/app/services/dashboard.service';
import { ActivatedRoute, Router } from '@angular/router';
import { map, share } from 'rxjs/operators';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { UserChecklist } from 'src/app/models/UserChecklist';
import { MatDialog } from '@angular/material';
import { UploadDialogComponent } from 'src/app/shared/UI/upload-dialog/upload-dialog.component';
import { SnackBarInfo } from 'src/app/services/snackbar-info.service';

@Component({
  selector: 'app-one-checklist',
  templateUrl: './one-checklist.component.html',
  styleUrls: ['./one-checklist.component.sass']
})
export class OneChecklistComponent implements OnInit {

  constructor(
    private dashboardService: DashboardService,
    private activeRouter: ActivatedRoute,
    private fb: FormBuilder,
    public dialog: MatDialog,
    private snackbarInfo: SnackBarInfo,
    private router: Router
    ) { }

  checkChecklist: FormGroup;
  currentChecklist: UserChecklist;
  isSaving = false;

  get fields(): FormArray {
    return this.checkChecklist.get('fields').value as FormArray;
  }

  userChecklist$ = this.dashboardService.userChecklist$.pipe(
    map((value: []) => {
      if (!value) {
        return null;
      }
      return value.find((element: any) => element.id === +this.activeRouter.snapshot.paramMap.get('id'));
    })
  );

  ngOnInit() {
    this.checkChecklist = this.fb.group({
      fields: '',
    });

    this.userChecklist$.subscribe(currentList => {
      this.currentChecklist = currentList;
      this.buildForm(currentList);
    });
  }

  saveChecklist() {
    this.currentChecklist.fields = this.checkChecklist.get('fields').value.value;
    this.dashboardService.put(this.currentChecklist).subscribe(
      ok => {
        this.snackbarInfo.formOk('Your list was updated');
      },
      error => {
        this.snackbarInfo.formError(error.message)
      });
  }

  buildForm(chelistField: any) {
    if (chelistField == null) {
      return null;
    }
    const checklistFields = [];
    for (const cf of chelistField.fields) {
      checklistFields.push(cf);
    }
    this.checkChecklist.get('fields').patchValue(this.fb.array(checklistFields));
  }

  openUploadDialog() {
    const dialogRef = this.dialog.open(UploadDialogComponent, {
      width: '50%',
      height: '50%',
      data: {
        checklistId: this.currentChecklist.id
      }
    });
  }
  goToDashboard() {
    this.router.navigate(['/dashboard']);
  }
}
