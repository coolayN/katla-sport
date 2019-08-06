import { DepartmentMainInfo } from '../models/department-main-info';

export class Department {
    constructor(
        public id: number,
        public parentId: number,
        public parentName: string,
        public name: string,
        public code: string,
        public isDeleted: boolean,
        public lastUpdated: string,
        public childDepartments:DepartmentMainInfo[]
    ) { }
}
