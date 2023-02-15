import { CustomerViewModel } from "./customer-view-model";

export class CustomerSampleViewModel{
    customers : CustomerViewModel[];
    pagesCount? : number;

    constructor(){
        this.customers = [];
    }
}