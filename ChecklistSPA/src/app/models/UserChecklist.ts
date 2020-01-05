import { IUserChecklist } from '../interfaces/IUserChecklist';
import { ChecklistField } from '../interfaces/IChecklistField';

export class UserChecklist implements IUserChecklist {
    name: string;
    fields: ChecklistField[];
    createdDate: string;

}
