use('ClusterPaymentsSimplified');

// db.getCollection('users').createIndex({ document:1}, { name: 'document_idx', unique: true });
// db.getCollection('users').getIndexes();
// db.getCollection('users').createIndex({ email: 1 }, { name: 'email_idx', unique: true});

var newUsers = [
  { 
    name: "Phineas", 
    document: "23022457901", 
    type: 1,
    email: "irmaodoferb@gmail.com", 
    password: "perry@39",
    wallet: {
      balance: 74523.64
    }
  }, 
  { 
    name: "Vasquez", 
    document: "53276664097", 
    type: 1,
    email: "tchubiraudaum@gmail.com", 
    password: "toscana_forever",
    wallet: {
      balance: 6459.97
    }
  },
  { 
    name: "Mandy", 
    document: "97764344000109", 
    type: 2,
    email: "onlymuse@outlook.com", 
    password: "12hot#muse",
    wallet: {
      balance: 362589.15
    }
  },
  { 
    name: "Jorel", 
    document: "98512361018", 
    type: 1,
    email: "irmaodoirmaodojorel@gmail.com", 
    password: "catarinabet7$",
    wallet: {
      balance: 147302.55
    }
  },
  { name: "Catatau - Comércio de mel", 
    document: "84814973000154", 
    type: 2,
    email: "catatz@comerciodomel.com", 
    password: "delicademelsecretasso",
    wallet: {
      balance: 204887.72
    }
  },
  { name: "Brock", 
    document: "35397859060", 
    type: 1,
    email: "meuonix@yahoo.com", 
    password: "menotaenfermerajoy",
    wallet: {
      balance: 19068.08
    }
  },
  { name: "Leonidas", 
    document: "36756340000", 
    type: 1,
    email: "spartacus@moscow.com", 
    password: "thisis...nothingbro@@",
    wallet: {
      balance: 23549.20
    }
  }
]

// db.getCollection('users').insertMany(newUsers);
db.getCollection('users').find({type: 1}, {_id: 0, name:1, type: 1, "wallet.balance":1}).sort({'wallet.balance': -1})
