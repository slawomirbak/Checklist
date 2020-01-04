import { IUserChecklist } from '../interfaces/IUserChecklist';
import { IChecklistField } from '../interfaces/IChecklistField';

export class UserChecklist implements IUserChecklist {
    name: string;
    fields: IChecklistField[];
    createdDate: string;

}