import { CustomerOrderSettingsEnum } from "../enums/customer-order-settings.enum";

export class GetCustomersByFilterRequestModel {
    searchWord: string;
    sortingBy: CustomerOrderSettingsEnum;
    byAscending: boolean;
    page: number;
    pageSize: number;

    constructor(searchWord: string, sortingBy: CustomerOrderSettingsEnum, byAscending: boolean, page: number, pageSize: number) {

        this.searchWord = searchWord,
        this.sortingBy = sortingBy,
        this.byAscending = byAscending,
        this.page = page,
        this.pageSize = pageSize
    }
}