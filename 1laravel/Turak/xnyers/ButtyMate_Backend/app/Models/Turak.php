<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Turak extends Model
{
    protected $table = 'turak';

    protected $fillable = [
        'kategoria_id',
        'leiras',
        'indulas',
        'tav',
        'aktiv',
        'kep',
    ];

    public $timestamps = false;

    public function kategoria()
    {
        return $this->belongsTo(Kategoriak::class, 'kategoria_id');
    }
}
