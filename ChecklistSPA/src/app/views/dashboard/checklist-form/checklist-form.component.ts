import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';
import { DashboardService } from 'src/app/services/checklist.service';
import { IUserChecklist } from 'src/app/interfaces/IUserChecklist';
import { Router } from '@angular/router';
import { UserChecklist } from 'src/app/models/UserChecklist';

@Component({
  selector: 'app-checklist-form',
  templateUrl: './checklist-form.component.html',
  styleUrls: ['./checklist-form.component.sass']
})
export class ChecklistFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private dashboardService: DashboardService, private router: Router) { }

  isSaving = false;
  checklistForm: FormGroup;
  get listFields(): FormArray {
    return this.checklistForm.get('listFields') as FormArray;
  }

  @Output() showList: EventEmitter<boolean> = new EventEmitter();
  @Output() checklistError: EventEmitter<string> = new EventEmitter<string>();
  @Output() checklistOk: EventEmitter<string> = new EventEmitter<string>();


  ngOnInit() {
    this.checklistForm = this.fb.group({
      name: ['', Validators.required],
      listFields: this.fb.array([])
    });
  }

  dropChanges() {
   this.showList.emit(true);
  }

  addFormControl() {
    const formField = this.fb.control('');
    this.listFields.push(formField);
  }

  hasError(controlName: string, errorName: string ): boolean {
    return this.checklistForm.controls[controlName].hasError(errorName);
  }

  createChecklist(checklistForm: IUserChecklist) {
    if(!this.checklistForm.valid) {
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
    return userChecklist;
  }
}
