import { IChecklistField } from './IChecklistField';

export interface IUserChecklist {
    name: string;
    fields: IChecklistField[] ;
    createdDate: string;
}
