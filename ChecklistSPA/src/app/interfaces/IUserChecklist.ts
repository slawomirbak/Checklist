import {ChecklistField } from './IChecklistField';

export interface IUserChecklist {
    name: string;
    fields: ChecklistField[] ;
    createdDate: string;
}
