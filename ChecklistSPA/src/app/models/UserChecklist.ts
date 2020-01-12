import { IUserChecklist } from '../interfaces/IUserChecklist';
import { ChecklistField } from '../interfaces/IChecklistField';
import { IChecklistImage } from '../interfaces/IChecklistImage';

export class UserChecklist implements IUserChecklist {
    id: string;
    name: string;
    fields: ChecklistField[];
    createdDate: string;
    checklistImages: IChecklistImage[] = [];
}
