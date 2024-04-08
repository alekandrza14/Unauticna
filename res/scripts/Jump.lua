-- defines a Jump function
function Jump (time)
	if (time>= 4) then
		return 10
	else
           	return 0
	end
end
function clamp(x,min,max)
	return x < min and min or x > max and max or x;
end


function Velosity (time,patrn)
local maxpatrn = 8;
patrn = math.fmod(patrn, maxpatrn);
	if (time>= 4 and patrn == 0) then
		vec3.y = 1;
		vec3.x = 1;
		vec3.z = 0;

		return vec3;
	elseif (time>= 4 and patrn == 1) then
		vec3.y = 1;
		vec3.z = 1;
		vec3.x = 0;

		return vec3;
	elseif (time>= 4 and patrn == 2) then
		vec3.y = 1;
		vec3.z = 0;
		vec3.x = 0;

		return vec3;


	elseif (time>= 4 and patrn == 3) then
		vec3.y = 1;
		vec3.z = -1;
		vec3.x = 0;

		return vec3;


	elseif (time>= 4 and patrn == 4) then
		vec3.y = 1;
		vec3.z = -1;
		vec3.x = 1;

		return vec3;

	elseif (time>= 4 and patrn == 5) then
		vec3.y = 1;
		vec3.z = -1;
		vec3.x = -1;

		return vec3;

	elseif (time>= 4 and patrn == 6) then
		vec3.y = 1;
		vec3.z = 1;
		vec3.x = 1;

		return vec3;



	elseif (time>= 4 and patrn == 7) then
		vec3.y = 1;
		vec3.z = 0;
		vec3.x = -1;

		return vec3;



	else
		vec3.y = 0;
		vec3.x = 0;
		vec3.z = 0;

           	return vec3;
	end
end