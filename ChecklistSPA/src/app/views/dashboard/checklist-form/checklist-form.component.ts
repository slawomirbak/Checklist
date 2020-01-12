import { Component, OnInit, Output, EventEmitter, ViewChild, AfterViewChecked, ViewChildren } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { DashboardService } from 'src/app/services/dashboard.service';
import { IUserChecklist } from 'src/app/interfaces/IUserChecklist';
import { Router } from '@angular/router';
import { UserChecklist } from 'src/app/models/UserChecklist';
import { ChecklistField } from 'src/app/interfaces/IChecklistField';

@Component({
  selector: 'app-checklist-form',
  templateUrl: './checklist-form.component.html',
  styleUrls: ['./checklist-form.component.sass']
})
export class ChecklistFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private dashboardService: DashboardService, private router: Router) { }

  isSaving = false;
  checklistForm: FormGroup;
  get fields(): FormArray {
    return this.checklistForm.get('fields') as FormArray;
  }

  @Output() showList: EventEmitter<boolean> = new EventEmitter();
  @Output() checklistError: EventEmitter<string> = new EventEmitter<string>();
  @Output() checklistOk: EventEmitter<string> = new EventEmitter<string>();

  @ViewChildren('.test') input;

  ngOnInit() {
    this.checklistForm = this.fb.group({
      name: ['', Validators.required],
      fields: this.fb.array([])
    });
  }


  dropChanges() {
   this.showList.emit(true);
  }

  addFormControl() {
    const formField = this.fb.control('');
    this.fields.push(formField);
  }

  hasError(controlName: string, errorName: string ): boolean {
    return this.checklistForm.controls[controlName].hasError(errorName);
  }

  createChecklist(checklistForm: IUserChecklist) {
    if (!this.checklistForm.valid) {
      return;
    }
    this.isSaving = true;
    const userChecklist = this.createUserChecklist(checklistForm);
    this.dashboardService.post('', userChecklist).subscribe(
      ok => {
        this.checklistOk.emit('Checklist was created suceffully.');
        this.isSaving = false;
        this.showList.emit(true);
      },
      error => {
        this.checklistError.emit(error);
        this.isSaving = false;
      }
    );
  }

  private createUserChecklist(checklistForm: IUserChecklist): UserChecklist {
    const userChecklist = new UserChecklist();
    userChecklist.name = checklistForm.name;
    userChecklist.fields = [];

    for (let i = 0; i < checklistForm.fields.length; i++) {
        const checklistField = new ChecklistField();
        checklistField.name = checklistForm.fields[i];
        userChecklist.fields.push(checklistField);
    }
    return userChecklist;
  }
}
