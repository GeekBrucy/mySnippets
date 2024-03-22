export interface IVessel {
  vesselId: number;
}
export interface ICarrier {
  carrierId: number;
}
export interface IReceiver {
  receiverId: number;
}
export interface ILinkedDataObj {
  isNew: boolean;
  id: number;
  previous: IVessel | ICarrier | null;
  current: ICarrier;
  next: ICarrier | IReceiver;
  desc: string;
}

export const data: ILinkedDataObj[] = [
  {
    isNew: false,
    id: 1,
    previous: null,
    current: {
      carrierId: 1
    },
    next: {
      carrierId: 2
    },
    desc: "Transition 1"
  },
  {
    isNew: false,
    id: 3,
    previous: {
      vesselId: 2
    },
    current: {
      carrierId: 3
    },
    next: {
      carrierId: 4
    },
    desc: "Transition 3",
  },
  {
    isNew: false,
    id: 5,
    previous: {
      carrierId: 4
    },
    current: {
      carrierId: 5
    },
    next: {
      carrierId: 6
    },
    desc: "Transition 5"
  },
  {
    isNew: false,
    id: 2,
    previous: {
      carrierId: 1
    },
    current: {
      carrierId: 2
    },
    next: {
      carrierId: 3
    },
    desc: "Transition 2"
  },
  {
    isNew: false,
    id: 4,
    previous: {
      carrierId: 3
    },
    current: {
      carrierId: 4
    },
    next: {
      carrierId: 5
    },
    desc: "Transition 4"
  },
  {
    isNew: false,
    id: 7,
    previous: {
      carrierId: 6
    },
    current: {
      carrierId: 7
    },
    next: {
      receiverId: 8
    },
    desc: "Transition 7"
  }
];
