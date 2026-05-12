<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Kategoriak extends Model
{
    protected $table = 'kategoriak';

    protected $fillable = [
        'nev',
    ];
    public $timestamps = false;

    public function turaks()
    {
        return $this->hasMany(Turak::class, 'kategoria_id');   
}
}