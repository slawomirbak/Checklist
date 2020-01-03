import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray, FormControl } from '@angular/forms';

@Component({
  selector: 'app-checklist-form',
  templateUrl: './checklist-form.component.html',
  styleUrls: ['./checklist-form.component.sass']
})
export class ChecklistFormComponent implements OnInit {

  constructor(private fb: FormBuilder) { }

  isSaving: false;
  checklistForm: FormGroup;
  get listField(): FormArray {
    return this.checklistForm.get('listField') as FormArray;
  }

  @Output() showList: EventEmitter<boolean> = new EventEmitter();

  ngOnInit() {
    this.checklistForm = this.fb.group({
      checklistName: ['', Validators.required],
      listField: this.fb.array([])
    });
  }

  dropChanges() {
    this.showList.emit(true);
  }
  addFormControl() {
    const formField = this.fb.control('');
    this.listField.push(formField);
    console.log(this.checklistForm);
  }

  hasError(controlName: string, errorName: string ): boolean {
    return this.checklistForm.controls[controlName].hasError(errorName);
  }
}
