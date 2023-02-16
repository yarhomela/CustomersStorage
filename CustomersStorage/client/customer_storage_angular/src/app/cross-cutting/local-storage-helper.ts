import  *  as CryptoJS from  'crypto-js';

export class LocalStorageHelper{
    private cryptoSecretKey = "well-known";

    public setOnLocalStorage(itemName : string, item : any){
        let json = JSON.stringify(item);
        let cryptoJson = this.encrypt(json);
        localStorage.setItem(itemName, cryptoJson);
    }
    
     public getFromLocalStorage(itemName : string) : any{
        let cryptoJson = localStorage.getItem(itemName)!;
        let emptyString = '';
        if(!this.isValidString(cryptoJson)){
            return emptyString
        }
        let json = this.decrypt(cryptoJson);
        return JSON.parse(json);
    }

    private encrypt(txt: string): string {
        let encryptObject = CryptoJS.AES.encrypt(txt, this.cryptoSecretKey);
        return encryptObject.toString();
    }
    
    private decrypt(txtToDecrypt: string): string {
        let encryptObject = CryptoJS.AES.decrypt(txtToDecrypt, this.cryptoSecretKey);
        return encryptObject.toString(CryptoJS.enc.Utf8);
    }

    private isValidString(text : string) : boolean{
        let isValid = text != null && text != undefined && text != '';
        return isValid
    }
}
