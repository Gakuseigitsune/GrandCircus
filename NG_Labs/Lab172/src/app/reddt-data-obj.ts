
export interface ReddtObj {

    kind: string,
    data: ReddtDataObj
}


export interface ReddtDataObj {

    after: string,
    dist: number,
    modhash: string,
    geo_filter: any,
    children: ReddtChildObj[],
    before: any,
};

export interface ReddtChildObj {

    kind: string,
    data: ReddtPostData
};
export interface ReddtPostData {

    title: string,
    preview:{

        images: ReddtImageObj[]
    },
    permalink: string
};
export interface ReddtImageObj {

    source:{
        url: string,
        width: number,
        height: number
    }
};
