<?php

namespace App\Models;

use Illuminate\Database\Eloquent\Model;

class Kategoriak extends Model
{
    protected $table = 'kategoriak';

    protected $guarded = [];

    public $timestamps = false;

    public function ingatlanok()
    {
        return $this->hasMany(ingatlanok::class, 'kategoria');
    }
}
