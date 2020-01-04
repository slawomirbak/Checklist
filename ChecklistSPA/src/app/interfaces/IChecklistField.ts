import { IChecklistImage } from './IChecklistImage';

export interface IChecklistField {
    name: string;
    completed: boolean;
    ChecklistImages: IChecklistImage[];
}
