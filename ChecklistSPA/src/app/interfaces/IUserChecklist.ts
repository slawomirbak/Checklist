import {ChecklistField } from './IChecklistField';
import { IChecklistImage } from './IChecklistImage';

export interface IUserChecklist {
    id: string;
    name: string;
    fields: ChecklistField[] ;
    createdDate: string;
    checklistImages: IChecklistImage[];
}
