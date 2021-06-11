export class Item {
    id?: number;
    itemName?:string;
    itemType?: number;
    attack?: number;
    defence?: number;
    health?: number;
    dropRate?: number;
    flameBonus?: number;
    glacierBonus?: number;
    lightningBonus?: number;
    poisonBonus?: number;
    dropGroup?: number;
    statMultiplier?: number;
    bonusMultiplier?:number;
    photo?: string;
    active?: boolean;
    deleteStatus?: boolean;
    createTime?: Date;
    updateTime?: Date;
    cost:number;
    itemAbout:string;
}
