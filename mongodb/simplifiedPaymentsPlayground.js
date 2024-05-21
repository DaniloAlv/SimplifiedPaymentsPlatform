use('ClusterPaymentsSimplified');

// db.getCollection('users').createIndex({ document:1}, { name: 'document_idx', unique: true });
// db.getCollection('users').getIndexes();
// db.getCollection('users').createIndex({ email: 1 }, { name: 'email_idx', unique: true});


db.getCollection('users').find();
db.getCollection('transfers').find();
